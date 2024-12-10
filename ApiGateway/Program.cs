using ApiGateway.PagesInfo;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<SideBar>();
builder.Services.AddHttpClient<ChatMessages>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowFrontend",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.MapGet("/api/sidebar/{id}", async (int id, SideBar sidebar) =>
{
    return await sidebar.GetSideBarData(id);
});

app.MapGet("/api/chatmessages/{chatid}/{offset}", async (int chatid, int offset, ChatMessages chatMessages) =>
{
    return await chatMessages.GetChatMessages(chatid,offset);
});


app.Run();

