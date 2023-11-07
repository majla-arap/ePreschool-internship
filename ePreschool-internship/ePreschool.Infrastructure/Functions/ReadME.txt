Za dodavanje funkcija u bazu potrebno je uraditi sljedeće:

	-	Desni klik na folder Functions (sloj Infrastructure) i odabrati opciju "Open in terminal"
	-	U terminalu izvršiti komandu(samo prilikom prvog korištenja): 

		dotnet tool install --global dbup-cli --version 1.6.5  

	-	Nakon instalacije CLI-a, izvršiti komandu:

		dbup upgrade