from srp_2 import User, UserValidator, PasswordHasher, UserRepository, WelcomeNotifier

class UserRegistration:
    """
    This class composes the various single-responsibility classes to perform the 'register a user' use-case.
    Each component has one reason to change, so this class only changes if the overall registration process changes.
    """
    def __init__(self, validator: UserValidator, hasher: PasswordHasher,
                 repo: UserRepository, notifier: WelcomeNotifier):
        self.validator = validator
        self.hasher = hasher
        self.repo = repo
        self.notifier = notifier

    def register(self, email: str, password: str) -> User:
        self.validator.validate(email, password)

        password_hash = self.hasher.hash(password)

        user = self.repo.create(email=email, password_hash=password_hash)

        self.notifier.send_welcome(user.email)

        return user
