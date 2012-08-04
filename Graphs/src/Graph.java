
import java.util.ArrayList;

public class Graph {
	private ArrayList<Vertex> vertexes;
	private ArrayList<Edge> edges;
	
	public Graph(){
		vertexes = new ArrayList<Vertex>();
		edges = new ArrayList<Edge>();
	}
	
	public boolean vertexExists(Vertex v){
		boolean toReturn = false;
		
		for(int i = 0; i < vertexes.size(); i++){
			if(vertexes.get(i).equals(v)){
				toReturn = true;
				break;
			}
		}
		
		return toReturn;
	}
	
	public boolean empty(){
		return vertexes.size() == 0;
	}
	
	public int shortestPath(Vertex start, Vertex end){
		int toReturn = -1;
		int[] labels = new int[vertexes.size()];
		int[] previous = new int[vertexes.size()];
		int[] distance = new int[vertexes.size()];
		Queue toCheck = new Queue();
		int added = 0;
		int index = 0;
		int index_prev = 0;
		Vertex curV = null;
		Edge curE = null;
		ArrayList<Vertex> seen = new ArrayList<Vertex>();
		
		for(int i = 0; i < vertexes.size(); i++){
			labels[i] = vertexes.get(i).getLabel();
			previous[i] = -1;
			if(vertexes.get(i).equals(start)){
				distance[i] = 0;
			}else{
				distance[i] = -1;
			}
		}
		
		toCheck.enqueue(start);
		
		while(!toCheck.isEmpty()){
			curV = toCheck.dequeue();
			
			for(int i = 0; i < edges.size(); i++){
				curE = edges.get(i);
				
				if(curE.getDirection() == 0){
					if(curE.getLeft().equals(curV)){
						for(int j = 0; j < labels.length; j++){
							if(labels[j] == curE.getLeft().getLabel()){
								index_prev = j;
							}
							if(labels[j] == curE.getRight().getLabel()){
								index = j;
							}
						}
						if(distance[index] == -1 || distance[index] > distance[index_prev] + curE.getWeight()){
							distance[index] = distance[index_prev] + curE.getWeight();
							previous[index] = curV.getLabel();
							toCheck.enqueue(curE.getRight());
						}
						
					}else if(curE.getRight().equals(curV)){
						for(int j = 0; j < labels.length; j++){
							if(labels[j] == curE.getRight().getLabel()){
								index_prev = j;
							}
							if(labels[j] == curE.getLeft().getLabel()){
								index = j;
							}
						}
						if(distance[index] == -1 || distance[index] > distance[index_prev] + curE.getWeight()){
							distance[index] = distance[index_prev] + curE.getWeight();
							previous[index] = curV.getLabel();
							toCheck.enqueue(curE.getLeft());
						}
					}
				}else if(curE.getDirection() == 1){
					if(curE.getLeft().equals(curV)){
						for(int j = 0; j < labels.length; j++){
							if(labels[j] == curE.getLeft().getLabel()){
								index_prev = j;
							}
							if(labels[j] == curE.getRight().getLabel()){
								index = j;
							}
						}
						if(distance[index] == -1 || distance[index] > distance[index_prev] + curE.getWeight()){
							distance[index] = distance[index_prev] + curE.getWeight();
							previous[index] = curV.getLabel();
							toCheck.enqueue(curE.getRight());
						}
					}
				}else if(curE.getDirection() == 2){
					if(curE.getRight().equals(curV)){
						for(int j = 0; j < labels.length; j++){
							if(labels[j] == curE.getRight().getLabel()){
								index_prev = j;
							}
							if(labels[j] == curE.getLeft().getLabel()){
								index = j;
							}
						}
						if(distance[index] == -1 || distance[index] > distance[index_prev] + curE.getWeight()){
							distance[index] = distance[index_prev] + curE.getWeight();
							previous[index] = curV.getLabel();
							toCheck.enqueue(curE.getLeft());
						}
					}
				}
			}
		}
		
		for(int i = 0; i < labels.length; i++){
			if(labels[i] == end.getLabel()){
				toReturn = distance[i];
			}
		}
		
		return toReturn;
	}
	
	public Queue breadthFirstTraversal(Vertex start){
		Queue toReturn = new Queue();
		Queue toSearch = new Queue();
		ArrayList<Vertex> verticesSeen = new ArrayList<Vertex>();
		Vertex curV = null;
		Edge curE = null;
		
		toSearch.enqueue(start);
		verticesSeen.add(start);
		
		while(!toSearch.isEmpty()){
			curV = toSearch.dequeue();
			toReturn.enqueue(curV);
			
			for(int i = 0; i < edges.size(); i++){
				curE = edges.get(i);
				if( curE.getDirection() == 0){
					if( curE.getLeft().equals(curV)){
						if(!inArrayList(verticesSeen, curE.getRight())){
							toSearch.enqueue(curE.getRight());
							verticesSeen.add(curE.getRight());
						}
					}else{
						if(!inArrayList(verticesSeen, curE.getLeft())){
							toSearch.enqueue(curE.getLeft());
							verticesSeen.add(curE.getLeft());
						}
					}
				}else if(curE.getDirection() == 1 && curE.getLeft().equals(curV)){
					if(!inArrayList(verticesSeen, curE.getRight())){
						toSearch.enqueue(curE.getRight());
						verticesSeen.add(curE.getRight());
					}
				}else if(curE.getDirection() == 2 && curE.getRight().equals(curV)){
					if(!inArrayList(verticesSeen, curE.getLeft())){
						toSearch.enqueue(curE.getLeft());
						verticesSeen.add(curE.getLeft());
					}
				}
			}
		}
		
		
		return toReturn;
	}
	
	public Queue depthFirstTraversal(Vertex start){
		Queue toReturn = new Queue();
		Stack toSearch = new Stack();
		ArrayList<Vertex> verticesSeen = new ArrayList<Vertex>();
		Vertex curV = null;
		Edge curE = null;
		
		toSearch.push(start);
		verticesSeen.add(start);
		
		while(!toSearch.isEmpty()){
			curV = toSearch.pop();
			toReturn.enqueue(curV);
			
			
			for(int i = 0; i < edges.size(); i++){
				curE = edges.get(i);
				if(curE.hasVertex(curV)){
					if( curE.getDirection() == 0){
						if( curE.getLeft().equals(curV)){
							if(!inArrayList(verticesSeen, curE.getRight())){
								toSearch.push(curE.getRight());
								verticesSeen.add(curE.getRight());
							}
						}else{
							if(!inArrayList(verticesSeen, curE.getLeft())){
								toSearch.push(curE.getLeft());
								verticesSeen.add(curE.getLeft());
							}
						}
					}else if(curE.getDirection() == 1 && curE.getLeft().equals(curV)){
						if(!inArrayList(verticesSeen, curE.getRight())){
							toSearch.push(curE.getRight());
							verticesSeen.add(curE.getRight());
						}
					}else if(curE.getDirection() == 2 && curE.getRight().equals(curV)){
						if(!inArrayList(verticesSeen, curE.getLeft())){
							toSearch.push(curE.getLeft());
							verticesSeen.add(curE.getLeft());
						}
					}
				}
			}
		}
		
		
		return toReturn;
	}
	
	public Edge getEdge(Vertex v1, Vertex v2, int direction){
		Edge toReturn = null;
		Edge curE = null;
		
		for(int i = 0; i < edges.size(); i++){
			curE = edges.get(i);
			
			if(curE.getDirection() == 0 && curE.getDirection() == direction){
				if((curE.getLeft().equals(v1) && curE.getRight().equals(v2))||(curE.getLeft().equals(v2) && curE.getRight().equals(v1))){
					toReturn = curE;
					break;
				}
			}else if(curE.getDirection() == 1 && curE.getLeft().equals(v1) && curE.getRight().equals(v2) && curE.getDirection() == direction){
				toReturn = curE;
				break;
			}else if(curE.getDirection() == 2 && curE.getLeft().equals(v2) && curE.getRight().equals(v1) && curE.getDirection() == direction){
				toReturn = curE;
				break;
			}
		}
		
		return toReturn;
	}
	
	public int size(){
		return vertexes.size();
	}
	
	public void addVertex(Vertex newVertex, Vertex after, int direction) throws Exception{
		if( newVertex == null){
			throw new Exception("Cannot add a null node to the graph");
		}
		if(after == null ){
			if(empty() && newVertex != null){
				vertexes.add(newVertex);
			}else if(!empty()){
				throw new Exception("Cannot add a node to an non-empty graph without adding an edge");
			}
		}else{
			vertexes.add(newVertex);
			edges.add(new Edge(after, newVertex, direction));
		}
	}
	
	public void addEdge(Vertex v1, Vertex v2, int direction) throws Exception{
		if(!empty()){
			edges.add(new Edge(v2, v1, direction));
		}else{
			throw new Exception("Cannot add a edge to an empty graph");
		}
	}
	
	public void printVertexList(){
		System.out.print("Vertices: [ ");
		for(int i = 0; i < vertexes.size(); i++){
			if(i == vertexes.size() - 1 ){
				System.out.println( vertexes.get(i).getLabel() + " ]");
			}else{
				System.out.print(vertexes.get(i).getLabel() + ", ");
			}
		}
	}
	
	public void printAdjacencyList(){
		Vertex curV = null;
		Edge curEdge = null;
		
		System.out.println("Adjacency List:");
		for(int i = 0; i < vertexes.size(); i++){
			curV = vertexes.get(i);
			System.out.printf("%5s", curV.getLabel() + ":");
			for(int j = 0; j < edges.size(); j++){
				curEdge = edges.get(j);
				if(curEdge.hasVertex(curV)){
					if(curEdge.getDirection() == 1 && curEdge.getLeft().equals(curV)){
						System.out.printf("%5s", curEdge.getRight().getLabel());
					}else if(curEdge.getDirection() == 2 && curEdge.getRight().equals(curV)){
						System.out.printf("%5s", curEdge.getLeft().getLabel());
					}else if(curEdge.getDirection() == 0){
						if(curEdge.getLeft().equals(curV)){
							System.out.printf("%5s", curEdge.getRight().getLabel());
						}else{
							System.out.printf("%5s", curEdge.getLeft().getLabel());
						}
					}
				}
			}
			System.out.println();
		}
	}
	
	public void printAdjacencyMatrix(){
		Vertex curV = null;
		Vertex curV2 = null;
		Edge curE = null;
		
		System.out.println("Adjacency Matrix:");
		System.out.printf("%5s", " ");
		
		for(int i = 0; i < vertexes.size(); i++){
			System.out.printf("%5s", vertexes.get(i).getLabel());
		}
		System.out.println();
		
		for(int i = 0; i < vertexes.size(); i++){
			curV = vertexes.get(i);
			System.out.printf("%5s", curV.getLabel());
			for(int j = 0; j < vertexes.size(); j++){
				curV2 = vertexes.get(j);
				
				curE = getEdge(curV, curV2, 0);
				if(curE == null)
					curE = getEdge(curV, curV2, 1);
				if(curE == null)
					curE = getEdge(curV, curV2, 2);
				if(curE != null){
					System.out.printf("%5d", curE.getWeight());
				}else{
					System.out.printf("%5s", " ");
				}
			}
			System.out.println();
		}
	}
	
	public void setEdgeWeight(Vertex v1, Vertex v2, int newWeight){
		for(int i = 0; i < edges.size(); i++){
			if((edges.get(i).getLeft().equals(v1) && edges.get(i).getRight().equals(v2)) || (edges.get(i).getRight().equals(v1) && edges.get(i).getLeft().equals(v2))){
				edges.get(i).setWeight(newWeight);
			}
		}
	}
	
	public boolean hasEdge(Vertex v1, Vertex v2){
		boolean toReturn = false;
		Edge curEdge = null;
		
		for(int i = 0; i < edges.size(); i++){
			curEdge = edges.get(i);
			if(curEdge.getDirection() == 0){
				if((curEdge.getLeft().equals(v1) && curEdge.getRight().equals(v2)) || 
						(curEdge.getRight().equals(v1) && (curEdge.getLeft().equals(v2))))
					toReturn = true;
			}else if(curEdge.getDirection() == 1){
				if(curEdge.getLeft().equals(v1)  && curEdge.getRight().equals(v2)){
					toReturn = true;
				}
			}else if(curEdge.getDirection() == 2){
				if(curEdge.getRight().equals(v1) && curEdge.getLeft().equals(v2)){
					toReturn = true;
				}
			}
		}
		
		return toReturn;
	}
	
	private boolean inArrayList(ArrayList<Vertex> al, Vertex v){
		boolean toReturn = false;
		
		for(int i = 0; i < al.size(); i++){
			if(al.get(i).equals(v)){
				toReturn = true;
			}
		}
		
		return toReturn;
	}
}
