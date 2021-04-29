namespace MTR.Commands
{
    using System;

    public delegate void ExecuteCommandDelegate(object obj);

    public delegate bool CanExecuteCommandDelegate(object obj);
}
