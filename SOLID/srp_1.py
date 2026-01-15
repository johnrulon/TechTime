
from dataclasses import dataclass


@dataclass
class User:
    id: int
    email: str
    password_hash: str


class UserService:
    """
    Violates SRP because it:
      - validates input
      - hashes passwords
      - persists to the database
      - sends a welcome email
    Multiple reasons to change => not SRP.
    """

    def __init__(self, db, email_client):
        self.db = db
        self.email_client = email_client

    def register_user(self, email: str, password: str) -> User:
        # 1) validate
        if "@" not in email:
            raise ValueError("Invalid email")
        if len(password) < 12:
            raise ValueError("Password too short")

        # 2) hash password
        password_hash = f"hashed({password})"

        # 3) persist
        user_id = self.db.insert_user(email=email, password_hash=password_hash)
        user = User(id=user_id, email=email, password_hash=password_hash)

        # 4) notify
        self.email_client.send(
            to=email,
            subject="Welcome!",
            body="Thanks for signing up."
        )

        return user
