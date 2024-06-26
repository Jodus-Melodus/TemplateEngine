import re

def populate_template(template: str, values: list[str]) -> None:
    regex: str = r"(<\S*>)"

    for value in values:
        template = re.sub(pattern=regex, repl=value, string=template, count=1)

    return template

if __name__ == "__main__":
    while True:

        template = input("Enter template > ")
        values = input("Enter values separated by commas > ").split(", ")

        print(populate_template(template, values))