package com.github.add;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.kohsuke.github.GHRepository;
import org.kohsuke.github.GitHub;
import org.kohsuke.github.GitHubBuilder;

/**
 * Servlet implementation class addUser
 */
@WebServlet("/addUser")
public class addUser extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public addUser() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		
		String user = request.getParameter("username");
		try{
			GitHub github = new GitHubBuilder().withOAuthToken("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").build();
			System.out.println(github);
			// GHRepository repo = github.createRepository(
			// 	"new-repository","this is my new repository",
			// 	"https://www.kohsuke.org/",true/*public*/);
			String name = "smit-cod/Hello-git";
			GHRepository repo = github.getRepository(name);
			//GHRepository repo =  github.getOrganization("hi-talent-org").getRepository("helloworld");
			//System.out.println(repo);
			repo.addCollaborators(github.getUser(user));
		}
		catch(Exception e){System.out.println(e);}
		
		response.sendRedirect("index.jsp");
	}

}
