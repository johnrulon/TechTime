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
    """One job: persistence (DB details live here)."""
    def __init__(self, db):
        self.db = db

    def create(self, email: str, password_hash: str) -> User:
        user_id = self.db.insert_user(email=email, password_hash=password_hash)
        return User(id=user_id, email=email)


class WelcomeNotifier:
    """One job: notifications (email provider/templates live here)."""
    def __init__(self, email_client):
        self.email_client = email_client

    def send_welcome(self, email: str) -> None:
        self.email_client.send(
            to=email,
            subject="Welcome!",
            body="Thanks for signing up."
        )
