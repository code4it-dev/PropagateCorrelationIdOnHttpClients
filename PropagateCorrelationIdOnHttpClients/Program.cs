namespace PropagateCorrelationIdOnHttpClients
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //https://gist.github.com/davidfowl/c34633f1ddc519f030a1c0c5abe8e867

            builder.Services.AddHttpClient("items")
                                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://en5xof8r16a6h.x.pipedream.net/"))
                                .AddHeaderPropagation(options => options.HeaderNames.Add("my-correlation-id"));

            builder.Services.AddHttpClient("items2")
                              .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://en5xof8r16a6h.x.pipedream.net"))
                              .AddHeaderPropagation(options => options.HeaderNames.Add("my-correlation-id2"));

            //builder.Services.AddHeaderPropagation(options =>
            //    options.HeaderNames.Add("my-correlation-id")
            //);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}