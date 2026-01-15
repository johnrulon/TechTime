
// Abstraction
class NotificationChannel {
  send(message) {
    throw new Error("Method 'send()' must be implemented.");
  }
}

// Concrete implementations
class EmailChannel extends NotificationChannel {
  send(message) {
    console.log(`EMAIL: ${message}`);
  }
}

class SmsChannel extends NotificationChannel {
  send(message) {
    console.log(`SMS: ${message}`);
  }
}

class PushChannel extends NotificationChannel {
  send(message) {
    console.log(`PUSH: ${message}`);
  }
}

// Service depends on the abstraction, not concrete types
class NotificationService {
  send(message, channel) {
    return channel.send(message);
  }
}

// Usage
const svc = new NotificationService();
svc.send("Build succeeded", new EmailChannel());
svc.send("Build succeeded", new SmsChannel());
svc.send("Build succeeded", new PushChannel());



// Extend without modifying NotificationService:
class SlackChannel extends NotificationChannel {
  send(message) {
    console.log(`SLACK: ${message}`);
  }
}

svc.send("Build succeeded", new SlackChannel()); // Works without modifying NotificationService
