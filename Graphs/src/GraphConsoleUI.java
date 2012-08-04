import java.util.Scanner;

public class GraphConsoleUI {
	public static void main(String[] args){
		processUserInput();
		System.out.println("");
		System.out.println("======End of Processing======");
	}
	
	private static void processUserInput(){
		Scanner scan = new Scanner(System.in);
		Graph g = null;
		String input = "";
		
		g = new Graph();
		System.out.println("Graph Created");
		try{
			g.addVertex(new Vertex(1), null, 1);
			System.out.println("Vertex 1 created");
			System.out.println("");
			
			while(!input.equalsIgnoreCase("quit") && !input.equalsIgnoreCase("q")){
				System.out.println("Enter a command(help for help menu): ");
				input = scan.nextLine().trim();
			
				if(!input.equalsIgnoreCase("quit") && !input.equalsIgnoreCase("q")){
					if(!processInput(input, g)){
						System.out.println("Invalid Command: " + input);
					}
				}
			}
		}catch(Exception e){
			System.err.println("There was an error creating the first vertex");
			e.printStackTrace();
		}
	}
	
	private static boolean processInput(String input, Graph g){
		boolean toReturn = false;
		String[] parsedInput = input.split("\\s+");
		
		if(parsedInput[0].equalsIgnoreCase("help") || parsedInput[0].equalsIgnoreCase("h") || parsedInput[0].equals("?")){
			printHelp();
			toReturn = true;
		}else if(parsedInput[0].equalsIgnoreCase("size")){
			printSize(g);
			toReturn = true;
		}else if(parsedInput[0].equalsIgnoreCase("add")){
			toReturn = processAddInput(parsedInput, g);
		}else if(parsedInput[0].equalsIgnoreCase("labels") || parsedInput[0].equalsIgnoreCase("l")){
			printLabels(g);
			toReturn = true;
		}else if(parsedInput[0].equalsIgnoreCase("adjlist") || parsedInput[0].equalsIgnoreCase("alist")){
			printAList(g);
			toReturn = true;
		}else if(parsedInput[0].equalsIgnoreCase("adjmatrix") || parsedInput[0].equalsIgnoreCase("amatrix")){
			printAMatrix(g);
			toReturn = true;
		}else if(parsedInput[0].equalsIgnoreCase("adde") || parsedInput[0].equalsIgnoreCase("addedge")){
			toReturn = processAddEdgeInput(parsedInput, g);
		}else if(parsedInput[0].equalsIgnoreCase("dftraversal") || parsedInput[0].equalsIgnoreCase("dft") || parsedInput[0].equalsIgnoreCase("depthfirsttraversal")){
			toReturn = processDFTInput(parsedInput, g);
		}else if(parsedInput[0].equalsIgnoreCase("bftraversal") || parsedInput[0].equalsIgnoreCase("bft") || parsedInput[0].equalsIgnoreCase("breadthfirsttraveral")){
			toReturn = processBFTInput(parsedInput, g);
		}else if(parsedInput[0].equalsIgnoreCase("setew") || parsedInput[0].equalsIgnoreCase("seteweight") || parsedInput[0].equalsIgnoreCase("setedgew") || 
				parsedInput[0].equalsIgnoreCase("setedgeweight")){
			toReturn = processSEWInput(parsedInput, g);
		}
		
		return toReturn;
	}
	
	private static boolean processSEWInput(String[] args, Graph g){
		boolean toReturn = false;
		int v1 = 0;
		int v2 = 0;
		int weight = 0;
		
		if(args.length == 4){
			try{
				v1 = Integer.parseInt(args[1]);
				v2 = Integer.parseInt(args[2]);
				weight = Integer.parseInt(args[3]);
				
				if(g.hasEdge(new Vertex(v1), new Vertex(v2))){
					g.setEdgeWeight(new Vertex(v1), new Vertex(v2), weight);
					toReturn = true;
				}else{
					System.out.println("Error! make sure the edge that you want to set the weight of exists");
				}
			}catch(NumberFormatException nfe){
				System.out.println("Error! setweight command arguments must be integers.");
			}
		}else{
			System.out.println("Error! seteweight command must have exactly 1 argument.");
		}
		
		return toReturn;
	}
	
	private static boolean processBFTInput(String[] args, Graph g){
		boolean toReturn = false;
		int v1 = 0;
		Queue traversal = null;
		
		if(args.length == 2){
			try{
				v1 = Integer.parseInt(args[1]);
				
				if(g.vertexExists(new Vertex(v1))){
					traversal = g.breadthFirstTraversal(new Vertex(v1));
					
					while(!traversal.isEmpty()){
						System.out.print(traversal.dequeue().getLabel() + " ");
					}
					System.out.println();
					
					toReturn = true;
				}else{
					System.out.println("Error! Make sure the vertex you are starting the breadth first traversal from exists.");
				}
			}catch(NumberFormatException nfe){
				System.out.println("Error! bftraversal command argument must be an integer.");
			}
		}else{
			System.out.println("Error! bftraversal command must have exactly 1 argument.");
		}
		
		return toReturn;
	}
	
	private static boolean processDFTInput(String[] args, Graph g){
		boolean toReturn = false;
		int v1 = 0;
		Queue traversal = null;
		
		if(args.length == 2){
			try{
				v1 = Integer.parseInt(args[1]);
				
				if(g.vertexExists(new Vertex(v1))){
					traversal = g.depthFirstTraversal(new Vertex(v1));
					
					while(!traversal.isEmpty()){
						System.out.print(traversal.dequeue().getLabel() + " ");
					}
					System.out.println();
					
					toReturn = true;
				}else{
					System.out.println("Error! Make sure the vertex you are starting the depth first traversal from exists.");
				}
			}catch(NumberFormatException nfe){
				System.out.println("Error! dftraversal command argument must be an integer.");
			}
		}else{
			System.out.println("Error! dftraversal command must have exactly 1 argument.");
		}
		
		return toReturn;
	}
	
	private static boolean processAddEdgeInput(String[] args, Graph g){
		boolean toReturn = false;
		int v1 = 0;
		int v2 = 0;
		int direction = 0;
		
		if(args.length == 4){
			try{
				v1 = Integer.parseInt(args[1]);
				v2 = Integer.parseInt(args[2]);
				direction = Integer.parseInt(args[3]);
				
				if(g.vertexExists(new Vertex(v1)) && g.vertexExists(new Vertex(v2))){
					try{
						g.addEdge(new Vertex(v1), new Vertex(v2), direction);
						toReturn = true;
					}catch(Exception e){
						System.out.println("Error! " + e.getMessage());
					}
				}else{
					System.out.println("Error! Make sure the verticies you are making an edge between exist.");
				}
			}catch(NumberFormatException nfe){
				System.out.println("Error! addedge command arguments must be integers.");
			}
		}else{
			System.out.println("Error! addedge command must have exactly 3 arguments.");
		}
		
		
		return toReturn;
	}
	
	private static boolean processAddInput(String[] arguments, Graph g){
		boolean toReturn = false;
		int newV = 0;
		int afterV = 0;
		int directionV = 0;
		
		if(arguments.length == 4){
			try{
				newV = Integer.parseInt(arguments[1]);
				afterV = Integer.parseInt(arguments[2]);
				directionV = Integer.parseInt(arguments[3]);
				
				if(!g.vertexExists(new Vertex(newV)) && g.vertexExists(new Vertex(afterV))){
					try{
						g.addVertex(new Vertex(newV), new Vertex(afterV), directionV);
						toReturn = true;
					}catch(Exception e){
						System.out.println("Error! " + e.getMessage());
					}
				}else{
					System.out.println("Error! Make sure the vertex you are adding(" + newV + ") does not already exist and the vertex you attaching it to(" +
							afterV + ") does exist.");
				}
			}catch(NumberFormatException nfe){
				System.out.println("Error! add command arguments must be integers.");
			}
		}else{
			System.out.println("Error! add command must have exactly 3 arguments.");
		}
			
		return toReturn;
	}
	
	private static void printLabels(Graph g){
		g.printVertexList();
	}
	
	private static void printSize(Graph g){
		System.out.println("The graph has " + g.size() + " vertices");
	}
	
	private static void printAList(Graph g){
		g.printAdjacencyList();
	}
	
	private static void printAMatrix(Graph g){
		g.printAdjacencyMatrix();
	}
	
	private static void printHelp(){
		System.out.println("======Command List======");
		System.out.printf("%25s     %-12s %n", "Command", "Description");
		System.out.printf("%25s     %-12s %n", "size", "Displays the number of vertices in the Graph");
		System.out.printf("%25s     %-12s %n", "add x y z", "Add a new vertex x with an edge of direction z between x and y. " + 
				"(z = 0 for a bidirectional edge, z = 1 for an edge from y to x, and z = 2 for an edge from x to y)");
		System.out.printf("%25s     %-12", "addedge x y z", "Add a edge between vertex x and vertex y with direction z. " +
				"(z = 0 for a bidirectional edge, z = 1 for an edge from y to x, and z = 2 for an edge from x to y)");
		System.out.printf("%25s     %-12s %n", "dftraversal x", "Prints a depth first traversal beginning at vertex x.");
		System.out.printf("%25s     %-12s %n", "bftraversal x", "Prints a breadth first traversal beginning at vertex x.");
		System.out.printf("%25s     %-12s %n", "labels(or l)", "Lists all the labels of the vertices in the graph.");
		System.out.printf("%25s     %-12s %n", "adjlist(or alist)", "Prints the adjacency list of the graph.");
		System.out.printf("%25s     %-12s %n", "adjmatrix(or amatrix)", "Prints the adjacency matrix of the graph.");
		System.out.printf("%25s     %-12s $n", "seteweight x y z", "Sets the weight of the edges, from x to y, to z.");
		System.out.printf("%25s     %-12s %n", "help( or h or ?)", "Displays the help menu");
		System.out.printf("%25s     %-12s %n", "quit( or q)", "Quits the program");
	}
}
