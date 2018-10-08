
[![Build status](https://ci.appveyor.com/api/projects/status/8n0dvk1rut8fr68t?svg=true)](https://ci.appveyor.com/project/aredfox/pheme)

# Pheme
<img src="http://4.bp.blogspot.com/-36B2w4BEa3o/Uq_gdrGXIoI/AAAAAAAAAts/nnC4jZT8HUY/s1600/fama_by_juja_anandini-d33ikp0.jpg" width="200" align="right"><p>The goal of the project is to create a reusable and extensible toolset which allows for communication/integration to various forums/social chatboxes/social networks and more... Think of slack, MS Teams, Facebook Messenger, Discord, and more...</p>
<p>According to [Wikipedia](https://en.wikipedia.org/wiki/Pheme "Wikipedia on Pheme"), the goddess Pheme (aka Fama, Ossa) was described as "she who initiates and furthers communication".  Pheme was said to have pried into the affairs of mortals and gods, then repeated what she learned, starting off at first with just a dull whisper, but repeating it louder each time, until everyone knew. In art, she was usually depicted with wings and a trumpet.</p>

# Structure
The structure is a simple one. Each application has it's own needs for sending notifications or messages, so I'm making no assumptions there. In interface of `IMessage` is the most abstract form there (the examples explore a minimal worked out example with a concrete `Message` class). When an `IMessage` is created it gets send to an `ITarget` which accepts a specific message and `IMessageConverter` - the converter makes sure there's a mapping between the shared `IMessage` and a concrere proprietary format the integration needs (e.g. the json format of slack, or the json format of teams). The rest is in the examples is .NET boiler plate code for bootstrapping and shows how one can expland `IServiceCollection` and `IConfigurationBuilder` so the consumer doesn't need to know all the necessary details.

# Contribute
Feel free to fork and/or send a pull request for features. Or simply hit the issues tab to report an issue or request a feature. Suggestions and perfections in design issues are always welcome.
