As a programmer for both Unity and Unreal, I often find tools or libraries in one engine that is not present in the other. One such library is Unreal Engine's TimerHandles. Unity certainly has its options for timers, but I've always liked Unreal's approach. This library isn't revolutionary, or anything super special, it is just another solution to creating timers in Unity in a way I liked from Unreal Engine.

<br><b> How To Use: </b>

<br> After loading files into your project, create an object in your scene and attach the WorldTimerManager script to it. This script is responsible for the management of your timers.

<br> In the script that you wish to have a timer, create a new variable of type TimeHandle. You must create it using the new keyword. You can do so when you define the variable, or before you intend to use the handle for the first time. Ex: private TimerHandle delayHandle = new TimerHandle();

<br> Create a float variable for the amount of time to pass before calling an action.

<br> In start or wherever you want the timer to begin, call WorldTimerManager.instance.SetTimer(). The method has five parameters, three of which are required. The first is the handle you created. This acts as the key for your timer and is stored as a dictionary key in the timermanager. The second is the action or method you want to call when the time is up. You can use a lambda or call a prexisting method. The third parameter is the float value before the action gets called. The fourth paramter is a bool to have the timer loop and continue calling the action, and the fifth is a delay value before the timer begins; both of these parameters are optional.

<br>Use the methods StopTimer, PauseTimer, and UnPauseTimer, passing in the handler, in order to control your timers.

<br><b>Enjoy</b>
