# StudentManagementSys
Belangrijk punten
1)
   Email bevesting werd in dit project niet geïmplementeerd.
   Na het aanmaken van een gebruiker is het noodzakelijk om via een update statement de kolom 'EmailConfirmed' op true te zetten.
  Vb => Update dbo.AspNetUsers set EmailConfirmed = 1 where id = 1
  
