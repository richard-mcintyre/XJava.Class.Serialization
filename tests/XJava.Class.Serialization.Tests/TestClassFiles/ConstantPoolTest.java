import java.lang.invoke.*;

public class ConstantPoolTest {

    interface TestIface
    {
        void TestInterfaceMethod();
    }

    private int minIntField = -2147483648;
    private int maxIntField = 2147483647;

    private long minLongField = -9223372036854775808L;
    private long maxLongField = 9223372036854775807L;

    public float floatField = 123.45f;

    public double doubleField = 456.78d;

    public static void main(String[] args)
        throws NoSuchMethodException, IllegalAccessException, Throwable
    {
        TestIface iface = new TestIface()
        {
            public void TestInterfaceMethod() { }
        };

        Runnable r = () -> System.out.println("test");
        Thread t = new Thread(r);
        t.start();
        t.join();

        /*MethodHandles.Lookup lookup = MethodHandles.lookup();
        MethodType mt = MethodType.methodType(String.class, Integer.class, char.class);
        MethodHandle mh = lookup.findVirtual(String.class, "replace", mt);
        String s = (String)mh.invokeExact("daddy", 'd','n');*/

        iface.TestInterfaceMethod();
        System.out.println("Hello World!");
    }
}
