
How to test ?
1. Make Sure you have ollama running with llama3.2:1b large language model. ( if you want you can try to use your own, preferably the same one but bigger)
2. localhost should match since by default it uses 11434 AiAnalysisLogic.cs/CreateAiResponseAsync
![image](https://github.com/user-attachments/assets/36da39ac-9353-4bea-83b5-f8fb02149d98)

Run debug through ISS Express.

![image](https://github.com/user-attachments/assets/c394ae46-6ca4-447e-bfe1-4c6af0327f0d)

**BUG**
Create a post request, here are some examples.
{
  "itSupportRequestId": 1,
  "userId": 1,
  "isSystem": true,
  "isModule": true,
  "description": "The application crashes every time I try to save a file.",
  "reproductionSteps": "Open the app, create a new document, click save.",
  "expectedResult": "The document should save without errors.",
  "priority": "High"
}

**CONSULTATION**
{
  "itSupportRequestId": 2,
  "userId": 2,
  "isSystem": true,
  "isModule": false,
  "description": "How do I reset my password in the system?",
  "reproductionSteps": "N/A",
  "expectedResult": "Instructions on password reset procedure.",
  "priority": "Medium"
}

**IMPROVMENT**
{
  "itSupportRequestId": 3,
  "userId": 3,
  "isSystem": true,
  "isModule": true,
  "description": "It would be helpful to have a dark mode in the application.",
  "reproductionSteps": "N/A",
  "expectedResult": "The app supports a dark mode option.",
  "priority": "Low"
}

**NOT RELATED TO INFROMATION SYSTEM**
{
  "itSupportRequestId": 5,
  "userId": 4,
  "isSystem": false,
  "isModule": false,
  "description": "A dog keeps entering the office and chewing on cables under the desks. This is causing a lot of distractions and might eventually damage something.",
  "reproductionSteps": "Leave the door open and wait — the dog usually comes in within 5 minutes.",
  "expectedResult": "The dog should be kept outside or prevented from entering the workspace.",
  "priority": "Medium"
}

When POST is executed, you could try to GET it through **/api/ITSupport** by id just to see if it is executed.
Then GET **/api/AiAnalysis/AiSupportReport** enter only required fields this should return something like this
![image](https://github.com/user-attachments/assets/5566a854-4a3a-4d30-a9a6-a56f2544d634)

**Possible improvments in future**
Put AI promt in seperate file
Use larger model ( could not do that locally since computer limitations)
Mask **AiAnalysis** fields that are not required for data getting.
Alhrough the string http://localhost:11434 for accessing a local Ollama server — does not contain sensitive data, it should better be masked in future. Same for llama3.2:1b
Add unit tests.
Move data to db rather than use list

