# assignment 02

### Kaydedilen şifreleri geri almaya yarayan UndoPassword classı : 

```python
 protected void UndoPassword()
    {
        public string text { get; set; } = "text-secondary";

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
  ### Geri alma butonu :
  
   ```python  
     <div class="col-md-1">
     <span @onclick="@(()=>UndoPassword())" class="oi oi-action-undo  @text " aria-hidden="true"></span>
     </div>
     
                        
    
   
     
    
