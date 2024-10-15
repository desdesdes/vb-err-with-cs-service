# vb-err-with-cs-service

This project displays what happens when a Visual Basic project uses the vb err object in a C# service.

Because the c# try catch doen not reset the err object (vb.net try catch does this), the vb.net code will not work as expected.

see the call to `[Microsoft.VisualBasic.Core]Microsoft.VisualBasic.CompilerServices.ProjectData::ClearProjectError()`

```il
.method public 
	instance void vbtrycatch () cil managed 
{
	// Method begins at RVA 0x210c
	// Header size: 12
	// Code size: 37 (0x25)
	.maxstack 2
	.locals init (
		[0] class [System.Runtime]System.Exception ex
	)

	// {
	IL_0000: nop
	.try
	{
		// {
		IL_0001: nop
		// Information.Err().Number = -2147220387;
		IL_0002: call class [Microsoft.VisualBasic.Core]Microsoft.VisualBasic.ErrObject [Microsoft.VisualBasic.Core]Microsoft.VisualBasic.Information::Err()
		IL_0007: ldc.i4 -2147220387
		IL_000c: callvirt instance void [Microsoft.VisualBasic.Core]Microsoft.VisualBasic.ErrObject::set_Number(int32)
		// }
		IL_0011: nop
		IL_0012: leave.s IL_0023
	} // end .try
	catch [System.Runtime]System.Exception
	{
		// ProjectData.SetProjectError(ex);
		IL_0014: dup
		IL_0015: call void [Microsoft.VisualBasic.Core]Microsoft.VisualBasic.CompilerServices.ProjectData::SetProjectError(class [System.Runtime]System.Exception)
		// Exception ex2 = ex;
		IL_001a: stloc.0
		// ProjectData.ClearProjectError();
		IL_001b: nop
		IL_001c: call void [Microsoft.VisualBasic.Core]Microsoft.VisualBasic.CompilerServices.ProjectData::ClearProjectError()
		// }
		IL_0021: leave.s IL_0023
	} // end handler

	// (no C# code)
	IL_0023: nop
	IL_0024: ret
} // end of method Class1::vbtrycatch
```