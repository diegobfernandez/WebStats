SimpleWebStats
==============

A  simple owin middleware to store client information.

Features
==============

I recommend this if your application need information about client requests such as:
* Browser vendor/Browser version
* OS vendor/OS version
* Device vendor/Device model

This is great to take decisions upon browser support, actually this was my motivation the make this middleware.

What haven't been done?
==============

So far I have not implemented:
* Persistence mechanisms. I'm thinking about including EF, NHibernate and Mongo support.
  For now you have to   implement persistence in your application.
  If you have time and want to contribute please send a pull request.
* Testing. No kind of tests were implemented.
  I want to, but I'm out of time. If you want to contribute go ahead, I would be so grateful!
* Advanced scenarios are not covered. Beside I have been careful about the extensibility of code I'm not sure about it useness.
  
Roadmap
==============

Please, open an Issue if you have an idea or found a bug?
I'm looking into planning a roadmap to this and some feedback would help a lot.
