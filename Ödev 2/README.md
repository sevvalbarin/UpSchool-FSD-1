# UpScool HomeWork 2 : Undo Password With Memento Pattern
## Link is below;
### https://localhost:7110/

## Demonstration of the application is below in the video

https://user-images.githubusercontent.com/92356404/223487383-a518457b-9111-4d6b-b509-f99eeea2728e.mp4

## The codes I added to our main project:

`<div class="card-body">
    <div class="row">
         <div class="col-md-8">
              <p>@password</p>
         </div>
         @if(PasswordMemento.Count > 1)
         {
            <div class="col-md-1">
                <span @onclick=@UndoPasswordMemento class="oi oi-action-undo clickable" aria-hidden="true"></span>
            </div>
         }
         else
         {
             <div class="col-md-1">
                 <span class="oi oi-action-undo text-secondary" aria-hidden="true"></span>
             </div>
          }
          <div class="col-md-1">
                  <span @onclick="@(() => SavePasswordAsync())" class="oi oi-folder clickable" aria-hidden="true"></span>
          </div>
              <div class="col-md-1">
                  <span @onclick="@(() => CopyToClipboardAsync())" class="oi oi-document clickable" aria-hidden="true"></span>
              </div>
              <div class="col-md-1">
                  <span @onclick=@GeneratePassword class="oi oi-loop-circular clickable" aria-hidden="true"></span>
              </div>
      </div>
</div>`
                        
`      
    Stack<string> PasswordMemento = new Stack<string>();


    private void UndoPasswordMemento()
    {
        PasswordMemento.Pop();
        password = PasswordMemento.Peek();
    }
                  `
### I added the following line of code to the GeneratePassword, CheckBoxOnChange and OnInputChange methods.      
 ` PasswordMemento.Push(password); `
   
