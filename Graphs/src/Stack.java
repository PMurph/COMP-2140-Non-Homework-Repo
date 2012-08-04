
public class Stack {
	private CircularLinkedList cll;
	
	public Stack(){
		cll = new CircularLinkedList();
	}
	
	public boolean isEmpty(){
		return cll.getSize() == 0;
	}
	
	public void push(Vertex v){
		cll.insertAtFront(v.getLabel());
	}
	
	public Vertex pop(){
		return new Vertex(cll.removeFromFront().getData());
	}
	
	public Vertex peek(){
		Vertex toReturn = new Vertex(cll.removeFromFront().getData());
		
		cll.insertAtFront(toReturn.getLabel());
		
		return toReturn;
	}
}
