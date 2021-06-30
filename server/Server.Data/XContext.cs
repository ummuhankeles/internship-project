using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    //todo: Context name change - (we have to find a project name for it.)
    public class XContext : DbContext
    {
        public XContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    }
}