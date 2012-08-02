
/* direction variable:
 * 0 = bidirectional 
 * 1 = left-to-right
 * 2 = right-to-left
 */

public class Edge {
	private Vertex left;
	private Vertex right;
	private int weight;
	private int direction;
	
	public Edge(Vertex l, Vertex r, int direction) throws Exception{
		left = l;
		right = r;
		
		weight = 1;
		
		if( direction < 0 || direction > 2){
			throw new Exception("Edge direction parameter must be 0(bidirectional), 1(left-to-right), or 2(right-to-left)");
		}else{
			this.direction = direction;
		}
	}
	
	public Vertex getLeft(){
		return left;
	}
	
	public Vertex getRight(){
		return right;
	}
	
	public boolean hasVertex(Vertex v){
		return left.equals(v) || right.equals(v);
	}
	
	public int getDirection(){
		return direction;
	}
	
	public int getWeight(){
		return weight;
	}
	
	public void setWeight(int setWeight){
		weight = setWeight;
	}
	
	
	public static Vertex followEdge(Edge toFollow, Vertex start) throws Exception{
		Vertex toReturn = null;
		
		if( toFollow.getDirection() == 0){
			if(toFollow.getLeft().equals(start)){
				toReturn = toFollow.getRight();
			}else if(toFollow.getRight().equals(start)){
				toReturn = toFollow.getLeft();
			}else{
				throw new Exception("start Vertex must be part of the the toFollow Edge in followEdge method");
			}
		}else if(toFollow.getDirection() == 1){
			if(toFollow.getLeft().equals(start)){
				toReturn = toFollow.getRight();
			}else{
				throw new Exception("start Vertex must be the left Vertex in the toFollow Edge with a direction of 1");
			}
		}else if(toFollow.getDirection() == 2){
			if(toFollow.getRight().equals(start)){
				toReturn = toFollow.getLeft();
			}else{
				throw new Exception("start Vertex must be the right Vertex in the toFollow Edge with a direction of 2");
			}
		}
		
		return toReturn;
	}
}
