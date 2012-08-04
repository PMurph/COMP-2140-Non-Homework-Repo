
public class Queue {
	private CircularLinkedList cll;
	
	public Queue(){
		cll = new CircularLinkedList();
	}
	
	public boolean isEmpty(){
		return cll.getSize() == 0;
	}
	
	public void enqueue(Vertex v){
		cll.insertAtFront(v.getLabel());
	}
	
	public Vertex dequeue(){
		return new Vertex(cll.removeFromBack().getData());
	}
	
	public Vertex peek(){
		Vertex toReturn = new Vertex(cll.removeFromBack().getData());
		
		cll.insertAtBack(toReturn.getLabel());
		
		return toReturn;
	}
}
