
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
			if(vertexes.get(i).equals(v))
				toReturn = true;
		}
		
		return toReturn;
	}
	
	public boolean empty(){
		return vertexes.size() == 0;
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
}
