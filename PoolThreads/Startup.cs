using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace PoolThreads
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var task = new Tasks();
            var taskManager = new TaskManager();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/task1", (thread) => 
            {
                thread.Run(async (context) =>
                {
                    Console.WriteLine("Trying add task1");
                    taskManager.AddCollection(task.FirstTask());
                });
            });


            app.Map("/task2", (thread) =>
            {
                thread.Run(async (context) =>
                {
                    Console.WriteLine("Trying add task2");
                    taskManager.AddCollection(task.SecondTask());
                });
            });

            app.Map("/task3", (thread) =>
            {
                thread.Run(async (context) =>
                {
                    Console.WriteLine("Trying add task3");
                    taskManager.AddCollection(task.ThirdTask());
                });
            });

            app.Run(async (context) =>
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("TaksManager Started");
                    taskManager.StartTask();
                });
            });
        }
    }
}
