using DemoWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiClientConsole
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5098/");
        public static async Task CallGetAllEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("ListAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String x = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }
        }
        public static async Task CallGetAllEmployeeJson()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employees = new List<EmpViewModel>();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("ListAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    //install Newtonsoft.Json using PackageManager
                    employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);
                    foreach (EmpViewModel emp in employees)
                    {
                        await Console.Out.WriteLineAsync($" {emp.EmployeeId}, {emp.FirstName}, {emp.LastName}, {emp.BirthDate}, {emp.HireDate}, {emp.Title}, {emp.City}, {emp.ReportsTo}");
                    }
                }
            }
        }
        public static async Task FindEmployeeById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                EmpViewModel emp = new EmpViewModel();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync($"FindEmployee?id={id}");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    //install Newtonsoft.Json using PackageManager
                    emp = JsonConvert.DeserializeObject<EmpViewModel>(json);
                    await Console.Out.WriteLineAsync($" {emp.EmployeeId}, {emp.FirstName}, {emp.LastName}, {emp.BirthDate}, {emp.HireDate}, {emp.Title}, {emp.City}, {emp.ReportsTo}");
                }
            }
        }
        public static async Task AddNewEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel employee = new EmpViewModel()
                {
                    FirstName = "William",
                    LastName = "John",
                    City = "NYC",
                    BirthDate = new DateTime(1980, 01, 01),
                    HireDate = new DateTime(2000, 01, 01),
                    Title = "Manager"
                };
                var myContent = JsonConvert.SerializeObject(employee);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpPost:
                HttpResponseMessage response = await client.PostAsync("AddEmployee", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteAsync(response.StatusCode.ToString());
                }
            }
        }
        public static async Task UpdateEmployee(EmpViewModel emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //EmpViewModel employee = new EmpViewModel()
                //{
                //    FirstName = "William",
                //    LastName = "John Cooper",
                //    City = "NYC",
                //    BirthDate = new DateTime(1980, 01, 01),
                //    HireDate = new DateTime(2000, 01, 01),
                //    Title = "Manager"
                //};
                var myContent = JsonConvert.SerializeObject(emp);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HttpPost:
                HttpResponseMessage response = await client.PutAsync($"ModifyEmployee", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteAsync(response.StatusCode.ToString());
                }
            }
        }
        public static async Task DeleteEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpPost:
                HttpResponseMessage response = await client.DeleteAsync($"DeleteEmployee?id={id}");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteAsync(response.StatusCode.ToString());
                }
            }
        }
    }
}
