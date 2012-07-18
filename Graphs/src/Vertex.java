public class Vertex {
	
	private int label;
	
	public Vertex(int label){
		this.label = label;
	}
	
	public int getLabel(){
		return label;
	}
	
	public boolean equals(Vertex toCompare){
		if(toCompare.getLabel() == this.label){
			return true;
		}
		
		return false;
	}
}
