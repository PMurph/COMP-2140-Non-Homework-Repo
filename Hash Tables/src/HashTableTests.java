
public class HashTableTests {
	public static void main(String[] args){
		testTableSize();
		testInsertToTable();
		testTableRetrieve();
		testTableDelete();
		System.out.println("====End of Processing====");
	}
	
	private static void testTableDelete(){
		System.out.println("====Retrieve Test 1====");
		System.out.println(">>Test a delete on an empty table");
		HashTable ht = new HashTable(5);
		ht.delete("Not in Table");
		System.out.println(ht.toString());
		System.out.println("Test Passed: " + (ht.toString().equals("[ , , , , ]")));
		System.out.println("");
		
		System.out.println("====Retrieve Test 2====");
		System.out.println(">>Test a delete on a table with a single element");
		ht.insert("red");
		ht.delete("red");
		System.out.println(ht.toString());
		System.out.println("Test Passed: " + (ht.toString().equals("[ , , , , ]")));
		System.out.println("");
		
		System.out.println("====Retrieve Test 3====");
		System.out.println(">>Test a delete on a element that has been placed after a collision");
		ht.insert("red");
		ht.insert("red");
		System.out.println(ht.toString());
		ht.delete("red");
		System.out.println(ht.toString());
		ht.delete("red");
		System.out.println(ht.toString());
		System.out.println("Test Passed: " + (ht.toString().equals("[ , , , , ]")));
		System.out.println("");
	}
	
	private static void testTableRetrieve(){
		System.out.println("====Retrieve Test 1====");
		System.out.println(">>Test a retrieve on an empty table");
		HashTable ht = new HashTable(7);
		System.out.println(ht.retrieve(4));
		System.out.println(ht.retrieveKey("test"));
		System.out.println("Test Passed: " + ((ht.retrieve(4) == null) && (ht.retrieveKey("test")==-1)));
		System.out.println("");
		
		System.out.println("====Retrieve Test 2====");
		System.out.println(">>Test a retrieve on a table with one element in it");
		ht.insert("a");
		System.out.println(ht.retrieve(6));
		System.out.println(ht.retrieveKey("a"));
		System.out.println("Test Passed: " + (ht.retrieve(6).equals("a") && ht.retrieveKey("a") == 6));
		System.out.println("");
		
		System.out.println("====Retrieve Test 3====");
		System.out.println(">>Test a retrieve on an item that had a collision");
		ht.insert("h");
		System.out.println(ht.retrieve(2));
		System.out.println(ht.retrieveKey("h"));
		System.out.println("Test Passed: " + (ht.retrieve(2).equals("h") && ht.retrieveKey("h") == 2));
		System.out.println("");
	}
	
	private static void testTableSize(){
		System.out.println("====Table Size Test 1====");
		System.out.println(">>Tests the size of the table created when 21 is passed to the constructor");
		HashTable ht = new HashTable(21);
		System.out.println("TableSize: " + ht.getTableSize());
		System.out.println("Test Passed: " + (ht.getTableSize()==19));
		System.out.println("");
		
		System.out.println("====Table Size Test 2====");
		System.out.println(">>Tests the size of the table created when 171 is passed to the constructor");
		ht = new HashTable(171);
		System.out.println("TableSize: " + ht.getTableSize());
		System.out.println("Test Passed: " + (ht.getTableSize()==167));
		System.out.println("");
		
		System.out.println("====Table Size Test 3====");
		System.out.println(">>Tests the size of the table created when 1867 is passed to the constructor");
		ht = new HashTable(1867);
		System.out.println("TableSize: " + ht.getTableSize());
		System.out.println("Test Passed: " + (ht.getTableSize()==199));
		System.out.println("");
	}
	
	private static void testInsertToTable(){
		String initial = "";
		System.out.println("====Insert Test 1====");
		System.out.println(">>Tests inserting into an empty table");
		HashTable ht = new HashTable(6);
		ht.insert("a");
		System.out.println(ht.toString());
		System.out.println("Test Passed: " + ht.toString().equals("[ , , a, , ]"));
		System.out.println("");
		
		System.out.println("====Insert Test 2====");
		System.out.println(">>Test inserting with a collision");
		ht.insert("z");
		System.out.println(ht.toString());
		System.out.println("Test Passed: " + ht.toString().equals("[ z, , a, , ]"));
		System.out.println("");
		
		System.out.println("====Insert Test 3====");
		System.out.println(">>Test inserting into a full table and inserting strings longer than one char");
		ht.insert("test");
		ht.insert("another test");
		ht.insert("full table");
		initial = ht.toString();
		System.out.println(initial);
		ht.insert("this should not be inserted");
		System.out.println(ht.toString());
		System.out.println("Test Passed: " + ht.toString().equals(initial));
		System.out.println("");
	}
}
