
public class HashTableTests {
	public static void main(String[] args){
		testTableSize();
		testInsertToTable();
		System.out.println("====End of Processing====");
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
