namespace Domain.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(int id, string name) : base($"The {name} with the Id = {id} was not found") { }
}