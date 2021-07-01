mig:
	cd ./Server.Data && dotnet ef --startup-project ../Server.WebAPI/ migrations add $(name) && cd ..
migrm:
	cd ./Server.Data && dotnet ef migrations remove --startup-project ../Server.WebAPI/ && cd ..
dbup:
	cd ./Server.Data && dotnet ef --startup-project ../Server.WebAPI/ database update && cd ..