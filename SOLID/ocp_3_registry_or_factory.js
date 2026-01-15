
const registry = new NotificationChannelRegistry();

// Register existing channels (one-time setup)
registry.register("email", () => new EmailChannel());
registry.register("sms", () => new SmsChannel());
registry.register("push", () => new PushChannel());

const svc = new NotificationService(registry);

svc.send("Build succeeded", "email");
svc.send("Build succeeded", "sms");
svc.send("Build succeeded", "push");

// To add a new channel, we just register it without modifying NotificationService:
registry.register("slack", () => new SlackChannel());
svc.send("Build succeeded", "slack"); // Works without modifying NotificationService