using Kolokwium2.Data;

namespace Kolokwium2.Services;

public class Service
{
    private readonly Context _context;

    public Service(Context context)
    {
        _context = context;
    }
}