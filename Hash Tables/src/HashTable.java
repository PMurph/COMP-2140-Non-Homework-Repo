
public class HashTable {
	public static final int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131,
		127, 131, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 199
	};
	
	
	private String[] table;
	private boolean[] prevUsed;
	private int tableSize;
	private int entries;
	private int hashPrime;
	
	public HashTable(int maxElements){
		tableSize = getClosestPrime(maxElements);
		table = new String[tableSize];
		prevUsed = new boolean[tableSize];
		for(int i = 0; i < tableSize; i++){
			table[i] = null;
			prevUsed[i] = false;
		}
		entries = 0;
		initializePrimes();
	}
	
	public boolean empty(){
		return (entries == 0);
	}
	
	public boolean full(){
		return (entries == tableSize);
	}
	
	public int getTableSize(){
		return tableSize;
	}
	
	public void insert(String data){
		int index = 0;
		
		if(!full()){
			index = hashFunction(data);
			
			while(table[index]!=null){
				index = (index + collisionFunction(data)) % tableSize ;
			}
			table[index] = data;
			prevUsed[index] = true;
			entries++;
		}
	}
	
	public void delete(String toDelete){
		int index = 0;
		if(!empty()){
			index = retrieveKey(toDelete);
			if(index != -1){
				table[index] = null;
				entries--;
			}
		}
	}
	
	public String retrieve(int key){
		return table[key%tableSize];
	}
	
	public int retrieveKey(String toFind){
		int toReturn = 0;
		int searched = 0;
		
		if(!empty()){
			toReturn = hashFunction(toFind);
			
			while((table[toReturn] == null || !table[toReturn].equals(toFind)) && prevUsed[toReturn] == true && searched < tableSize){
				toReturn = (toReturn + collisionFunction(toFind)) % tableSize;
				searched++;
			}
			if(table[toReturn] == null || !table[toReturn].equals(toFind)){
				toReturn = -1;
			}
		}else{
			toReturn = -1;
		}
		
		return toReturn;
	}
	
	public String toString(){
		String toReturn = "[ ";
		
		for(int i = 0; i < tableSize - 1; i++){
			if(table[i] != null){
				toReturn += table[i] + ", ";
			}else{
				toReturn += ", ";
			}
		}
		
		if(table[tableSize-1] != null){
			toReturn += table[tableSize-1] + "]";
		}else{
			toReturn += "]";
		}
		
		return toReturn;
	}
	
	private int collisionFunction(String toHash){
		long beforeMod = 0;
		
		for(int i = 0; i < toHash.length(); i++){
			beforeMod = (beforeMod * hashPrime + (int)toHash.charAt(i)) % (tableSize-1);
		}
		
		return (int)(beforeMod % (tableSize-1)) + 1;
	}
	
	private int hashFunction(String toHash){
		long beforeMod = 0;
		
		for(int i = 0; i < toHash.length(); i++){
			beforeMod = (beforeMod * hashPrime + (int)toHash.charAt(i)) % tableSize;
		}
		
		return (int)(beforeMod % tableSize);
	}
	
	private void initializePrimes(){
		hashPrime = HashTable.primes[(int)(Math.random() * HashTable.primes.length)];
	}
	
	private int getClosestPrime(int maxElements){
		int toReturn = 0;
		for( int i = 0; i < HashTable.primes.length; i++){
			if(i == HashTable.primes.length - 1 && maxElements >= HashTable.primes[i]){
				toReturn = HashTable.primes[i];
			}else if( maxElements >= HashTable.primes[i] ){
				toReturn = HashTable.primes[i];
			}
		}
		return toReturn;
	}
	
	//===================================================
	//Main Method
	//===================================================
	public static void main(String[] args){
		
	}
}
