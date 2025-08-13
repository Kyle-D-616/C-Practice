using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using var db = new BloggingContext();

Console.WriteLine($"Database path: {db.DbPath}");

Console.WriteLine("Inserting a new blog");

db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
await db.SaveChangesAsync();

Console.WriteLine("Querying for a blog");
var blog = await db.Blogs
	.OrderBy(b => b.BlogId)
	.FirstAsync();

Console.WriteLine("Updating the blog and adding a ppost");
blog.Posts.Add(
	new Post { Title = "Hello World", Content ="I wrote an app using EF Core!"});
await db.SaveChangesAsync();
