using ApiMvcIp2021.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMvcIp2021.Data.AppDbContext
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
				: base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Cliente> Clientes { get; set; }

		//public DbSet<Categoria> Categorias { get; set; }
		//public DbSet<Subcategoria> Subcategorias { get; set; }
		//public DbSet<Cuenta> Cuentas { get; set; }
		//public DbSet<Concepto> Conceptos { get; set; }
		//public DbSet<ConceptoPredial> ConceptosPredial { get; set; }

		//public DbSet<Pago> Pagos { get; set; }
		//public DbSet<Licencia> Licencias { get; set; }
		//public DbSet<Predial> Predials { get; set; }
		//public DbSet<Poliza> Polizas { get; set; }
		//public DbSet<PolizaFederal> PolizasFederal { get; set; }
		//public DbSet<Verificacion> Verificaciones { get; set; }

	}
}
