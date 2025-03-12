Database First Approach Command:

	Scaffold-DbContext "Host=localhost;Port=5432;Database=mydb;user=postgres;password=idk" Provider -OutputDir Models
	# provider {
		postgresql: bpgsql.EntityFrameworkCore.PostgreSQL,
	}