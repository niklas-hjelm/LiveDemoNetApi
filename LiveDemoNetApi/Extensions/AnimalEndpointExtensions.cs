namespace LiveDemo.Extensions;

public static class AnimalEndpointExtensions
{
    public static IEndpointRouteBuilder MapAnimalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/animal");

        //CREATE
        group.MapPost("/", AddAnimal);
        //READ
        group.MapGet("/", GetAllAnimals);
        //UPDATE
        group.MapPut("/{id}", ReplaceAnimal);
        group.MapPatch("/{id}", UpdateAnimal);
        //DELETE
        group.MapDelete("/{id}", RemoveAnimal);

        return app;
    }

    private static void RemoveAnimal(AnimalService service, int id)
    {
        service.RemoveAnimal();
    }

    private static void UpdateAnimal(AnimalService service, string type, int id)
    {
        service.Animals[id].Type = type;
    }

    private static void ReplaceAnimal(AnimalService service, int id, Animal animal)
    {
        service.Animals[id] = animal;
    }

    private static List<Animal> GetAllAnimals(AnimalService service)
    {
        return service.Animals;
    }

    private static void AddAnimal(AnimalService service, Animal animal)
    {
        service.Animals.Add(animal);
    }
}