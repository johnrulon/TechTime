from dataclasses import dataclass


@dataclass
class User:
    id: int
    email: str


class UserValidator:
    """One job: validate registration input."""
    def validate(self, email: str, password: str) -> None:
        if "@" not in email:
            raise ValueError("Invalid email")
        if len(password) < 12:
            raise ValueError("Password too short")


class PasswordHasher:
    """One job: hash passwords."""
    def hash(self, password: str) -> str:
        return f"hashed({password})"


class UserRepository:
    """One job: persistence."""
    def __init__(self, db):
        self.db = db

    def create(self, email: str, password_hash: str) -> User:
        user_id = self.db.insert_user(email=email, password_hash=password_hash)
        return User(id=user_id, email=email)


class WelcomeNotifier:
    """One job: notifications."""
    def __init__(self, email_client):
        self.email_client = email_client

    def send_welcome(self, email: str) -> None:
        self.email_client.send(
            to=email,
            subject="Welcome!",
            body="Thanks for signing up."
        )


class UserRegistration:
    """
    Composition:
    Composes multiple single-responsibility classes to perform the full registration workflow.
    """
    def __init__(
        self,
        validator: UserValidator,
        hasher: PasswordHasher,
        repo: UserRepository,
        notifier: WelcomeNotifier
    ):
        self.validator = validator
        self.hasher = hasher
        self.repo = repo
        self.notifier = notifier

    def register_user(self, email: str, password: str) -> User:
        # 1) validate
        self.validator.validate(email, password)

        # 2) hash password
        password_hash = self.hasher.hash(password)

        # 3) persist
        user = self.repo.create(email=email, password_hash=password_hash)

        # 4) notify
        self.notifier.send_welcome(user.email)

        return user
