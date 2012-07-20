
public class CircularLinkedList {
	private DoublyLinkedNode dummy;
	private int size;
	
	public CircularLinkedList(){
		DoublyLinkedNode dummyNode = new DoublyLinkedNode(0);
		dummyNode.setDummy();
		dummyNode.setNext(dummyNode);
		dummyNode.setPrev(dummyNode);
	    size = 0;
	}
	
	public void insertAtFront(int toInsert){
		DoublyLinkedNode toAdd = new DoublyLinkedNode(toInsert);
		
		toAdd.setNext(dummy.getNext());
		dummy.getNext().setPrev(toAdd);
		dummy.setNext(toAdd);
		toAdd.setPrev(dummy);
		size++;
	}
	
	public void insertAtBack(int toInsert){
		DoublyLinkedNode toAdd = new DoublyLinkedNode(toInsert);
		
		toAdd.setPrev(dummy.getPrev());
		dummy.getPrev().setNext(toAdd);
		dummy.setPrev(toAdd);
		toAdd.setNext(dummy);
		size++;
	}
	
	public DoublyLinkedNode removeFromFront(){
		DoublyLinkedNode toReturn = null;
		
		if(dummy.getNext() != dummy){
			toReturn = dummy.getNext();
			
			dummy.setNext(dummy.getNext().getNext());
			dummy.getNext().setPrev(dummy);
			size--;
		}
		
		return toReturn;
	}
	
	public DoublyLinkedNode removeFromBack(){
		DoublyLinkedNode toReturn = null;
		
		if(dummy.getPrev() != dummy){
			toReturn = dummy.getPrev();
			
			dummy.setPrev(dummy.getPrev().getPrev());
			dummy.getPrev().setNext(dummy);
			size--;
		}
		
		return toReturn;
	}
	
	public int getSize(){
		return size;
	}
}
