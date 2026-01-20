
class NotificationService {
  send(message, channel) {
    if (channel === "email") {
      // send via email provider
      console.log(`EMAIL: ${message}`);
    } else if (channel === "sms") {
      // send via SMS provider
      console.log(`SMS: ${message}`);
    } else if (channel === "push") {
      // send via push provider
      console.log(`PUSH: ${message}`);
    } else {
      throw new Error("Unknown channel");
    }

    // Future channel types would require modifying this method
  }
}

// Usage
const svc = new NotificationService();
svc.send("Build succeeded", "email");
svc.send("Build succeeded", "sms");
svc.send("Build succeeded", "push");


// To add a new channel, we must modify NotificationService:
svc.send("Build succeeded", "slack"); // Error: Unknown channel
