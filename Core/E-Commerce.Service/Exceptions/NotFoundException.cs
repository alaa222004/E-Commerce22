using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Exceptions;

public abstract class NotFoundExceptioncs(string message):Exception(message);
public sealed class ProductNotFoundException(int id):
    NotFoundExceptioncs($"product with id{id}not found");
public sealed class BasketNotFoundException(int id) :
    NotFoundExceptioncs($"product with id{id}not found");


