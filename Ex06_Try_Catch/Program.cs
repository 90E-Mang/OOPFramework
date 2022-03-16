using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_Try_Catch
{
    // 예외처리 : 개발자가 코드를 통해서 문제를 발생시킴....
    // ㄴ> 개선의 여지가 있다 !
    // ? 걍 처음부터 잘하면 되지? -> 내가 만든 코드가 문제가 있을지 없을지 확신하지 못함.

    // try ~ catch ~ finally
    // 코드를 수정하는 것이 아니라 프로그램이 강제로 죽는 것을 방지하기 위함.
    // 예외처리로 문제를 인지하고 추후에 코드를 수정해야됨.
    class Program
    {
        static void Main(string[] args)
        {
            // string str = null;
            // Console.WriteLine(str.ToString());  // 예외가 발생 >> System.NullReferenceException >> 여기서 프로그램 강제종료됨.
            // Console.WriteLine("성공 종료");

            // 처리되지 않은 예외: System.NullReferenceException: 개체 참조가 개체의 인스턴스로 설정되지 않았습니다.
            // 위치: Ex06_Try_Catch.Program.Main(String[] args) 파일 D:\Ecount\Labs\OOPFramework\Ex06_Try_Catch\Program.cs:줄 21

            string str = null;
            try
            {
                Console.WriteLine(str.ToString());  // 문제가 발생

                // 내부적으로 ... 예외를 담을 수 있는 객체가 자동생성됨 -> 그 객체에 문제를 담음 -> 그 주소값을 아래의 e라는 변수에 전달함.

                // 1. 계층구조 : https://docs.microsoft.com/ko-kr/dotnet/api/system.nullreferenceexception?view=net-6.0
                // public class NullReferenceException : SystemException
                // 상속 : object -> Exception -> SystemException -> NullReferenceException

                // 2. 부모타입 변수는 자식타입의 주소를 받을 수 있다 (다형성)

                // 3. Exception e = new NullReferenceException("문제 발생에 관한 코드.... 문자열")
                // try 문제가 생기면..... 자동으로 그 문제에 대한 객체를 생성.... new NullReferenceException("문제 발생에 관한 코드.... 문자열")

                // 4. 그런데 catch(Exception e) 코드로 왜 생성할까? catch(NullReferenceException e) 로 정확하게 잡으면 되는디...
                
                // 5. ㄴ 왜냐하면 어떤 오류가 날지 모르기 때문에 모든 오류 객체의 주소값을 받을 수 있는 부모클래스인 Exception e 로 씀.

                // 6. catch 문을 여러번 쓸 수 있는데 하위 Exception을 먼저 쓰고 제일 마지막에 Exception으로 함.

                // 7. 코드에 try ~ catch를 쓰는건 결국 비용이든다... 근데 씀 .. why? 모든 오류를 알 수 없으니까 완벽하게 짤 자신이 없음...
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                // 1. 예외를 잡아둔 catch 부분에서 log 파일에 정보(어디서 무슨 예외가 발생했는지)를 기록
                // 2. 메일 시스템 연동해서 메일을 관리자(담장자)에게 내용 전송 >> 수정사항을 파악함.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("성공 종료");
        }
    }
}
