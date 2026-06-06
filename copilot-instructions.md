# Copilot Instructions

# User Preferences
- Target .NET 10 and latest ASP.NET Core.
- Use F# for high-performance parts.
- Optimize commands and file paths for Ubuntu Linux.
- Use modern C# features (collection expressions, primary constructors, raw string literals).
- Core principles: Follow SOLID, DRY, KISS, YAGNI, and minimalism.
- Organization: Group files into folders based on their logical role and function.
- Variables: Use descriptive names with a minimum of 5 characters.
- Comments: Write English comments as impersonal, direct statements of fact, without trailing periods. Never delete or overwrite existing user comments.
- Chat style: Answer in Russian, use an informal tone, clear visual structure, headers, and emojis.

## Code Generation Rules
- Be concise: Avoid wrapping code in conversational explanations.
- Do not hallucinate: Use only existing, real APIs and libraries. Do not invent methods.
- Refactoring: When modifying code, output only the changed lines or specific blocks, not the whole file.

# Commit Messages Generation (CRITICAL MANDATE)
When asked to generate, write, or suggest a commit message, you MUST strictly adhere to these absolute constraints. The output is directly fed into an automated CI/CD parser, so any deviation will break the pipeline.

## ABSOLUTE CONSTRAINTS:
1. OUTPUT EXACTLY ONE SINGLE LINE.
2. NEVER wrap the output in markdown code blocks (```). NO backticks, NO quotes.
3. NEVER add any conversational filler, explanations, prefixes, or postscripts.
4. STRICTLY follow the Conventional Commits specification.

## FORMAT:
type(scope): description

## RULES FOR FIELDS:
- type: MUST be exactly one of: feat, fix, docs, style, refactor, test, chore
- scope: MUST be lowercase only. Represents the module, component, or folder affected.
- description: MUST be in English, written in the imperative mood.
- TRAILING PERIODS ARE STRICTLY FORBIDDEN. Do NOT put a dot at the end.

## GOOD EXAMPLES (FOLLOW THIS EXACTLY):
feat(auth): add login validation logic
fix(database): resolve connection timeout during migration
docs(readme): update deployment instructions for ubuntu