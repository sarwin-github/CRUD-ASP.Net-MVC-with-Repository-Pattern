namespace EmployeeTest.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateStoredProcedure(
                "dbo.Employee_Insert",
                p => new
                    {
                        FirstName = p.String(),
                        LastName = p.String(),
                        Age = p.Int(),
                        Birthday = p.DateTime(),
                        Department = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Employee]([FirstName], [LastName], [Age], [Birthday], [Department])
                      VALUES (@FirstName, @LastName, @Age, @Birthday, @Department)
                      
                      DECLARE @EmployeeID int
                      SELECT @EmployeeID = [EmployeeID]
                      FROM [dbo].[Employee]
                      WHERE @@ROWCOUNT > 0 AND [EmployeeID] = scope_identity()
                      
                      SELECT t0.[EmployeeID]
                      FROM [dbo].[Employee] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[EmployeeID] = @EmployeeID"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Update",
                p => new
                    {
                        EmployeeID = p.Int(),
                        FirstName = p.String(),
                        LastName = p.String(),
                        Age = p.Int(),
                        Birthday = p.DateTime(),
                        Department = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Employee]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Age] = @Age, [Birthday] = @Birthday, [Department] = @Department
                      WHERE ([EmployeeID] = @EmployeeID)"
            );
            
            CreateStoredProcedure(
                "dbo.Employee_Delete",
                p => new
                    {
                        EmployeeID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Employee]
                      WHERE ([EmployeeID] = @EmployeeID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Employee_Delete");
            DropStoredProcedure("dbo.Employee_Update");
            DropStoredProcedure("dbo.Employee_Insert");
            DropTable("dbo.Employee");
        }
    }
}
