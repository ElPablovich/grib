var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<mushrooms> rep =
[
    new ("boletus","white-brown","one can", 3),
    new ("honey mushrooms","creamy","one can", 4),
    new ("pale grebe","white","it is forbidden", 2),
    new ("fly agaric","red","it is forbidden", 1)
];

app.MapGet("/", () => rep);
app.MapPost("/", (mushroomsDTO dto) =>
{
    mushrooms grib = new mushrooms(dto.name, dto.color, dto.eat, dto.age);
    rep.Add(grib);
});
app.MapPut("/obnova/{name}", (string name, mushroomsDTO dto) =>
{
    mushrooms buff = rep.Find(x => x.Name == name);
    buff.Name = dto.name;
    buff.Color = dto.color;
    buff.Eat = dto.eat;
    buff.Age = dto.age;

});
app.Run();

record class mushroomsDTO (string name, string color, string eat, int age);
class mushrooms
{
    string name;
    string color;
    string eat;
    int age;

    public mushrooms(string name, string color, string eat, int age)
    {
        Name = name;
        Color = color;
        Eat = eat;
        Age = age;
    }

    public string Name { get => name; set => name = value; }
    public string Color { get => color; set => color = value; }
    public string Eat { get => eat; set => eat = value; }
    public int Age { get => age; set => age = value; }
}