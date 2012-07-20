
public class DoublyLinkedNode {
	private int data;
	private DoublyLinkedNode next;
	private DoublyLinkedNode prev;
	boolean dummy;
	
	public DoublyLinkedNode(int data){
		this.data = data;
		next = null;
		prev = null;
		dummy = false;
	}
	
	public void setNext(DoublyLinkedNode newNext){
		next = newNext;
	}
	
	public DoublyLinkedNode getNext(){
		return next;
	}
	
	public void setPrev(DoublyLinkedNode newPrev){
		prev = newPrev;
	}
	
	public DoublyLinkedNode getPrev(){
		return prev;
	}
	
	public void setDummy(){
		dummy = true;
	}
	
	public boolean isDummy(){
		return dummy;
	}
	
	public int getData(){
		return data;
	}
}
