# assignment 02

### ```

 protected void UndoPassword()
    {
        if (savedPasswords.Any())
        {
            text="text-dark";
            IsDisable = true;
            int length = savedPasswords.Count;
            savedPasswords.RemoveAt(length-1);
            length = length -1 ;

        }else
        {
            text = "text-secondary";
            IsDisable = false;
        }
           
    }
```
