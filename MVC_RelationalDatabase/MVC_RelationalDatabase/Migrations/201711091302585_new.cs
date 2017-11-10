namespace MVC_RelationalDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        Teacher_TID = c.Int(nullable: false),
                        Course_CID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TID, t.Course_CID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_TID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CID, cascadeDelete: true)
                .Index(t => t.Teacher_TID)
                .Index(t => t.Course_CID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCourses", "Course_CID", "dbo.Courses");
            DropForeignKey("dbo.TeacherCourses", "Teacher_TID", "dbo.Teachers");
            DropIndex("dbo.TeacherCourses", new[] { "Course_CID" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_TID" });
            DropTable("dbo.TeacherCourses");
        }
    }
}
