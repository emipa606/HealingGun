# GitHub Copilot Instructions for Healing Gun (Continued) Mod

## Mod Overview and Purpose

The "Healing Gun (Continued)" mod introduces a unique weapon to RimWorld—a Healing Gun. Inspired by the original mod by erdelf, this continuation project revives and updates its functionality. This sophisticated weapon requires considerable effort and resources to produce. Its primary purpose is to provide immediate healing to injuries sustained during battles, enhancing the tactical depth of combat experiences in RimWorld.

### Purpose

- To provide emergency battlefield healing capabilities.
- To add a strategic layer to combat by managing injuries on the fly.
- To offer a high-cost, high-impact tool for mid-to-late game scenarios.

## Key Features and Systems

- **Unique Weapon Mechanic:** The Healing Gun is a complex weapon with significant crafting requirements. It operates by healing injuries during combat.
- **Research Requirement:** Players must unlock the Healing Gun through research to utilize it, ensuring it is integrated naturally into the game's progression.
- **Healing Constraints:** 
  - Each shot from the Healing Gun can heal up to six injuries.
  - It targets up to two injuries per body part.
  - It does not heal scars, old wounds, or regrow lost body parts.
  - It is ineffective against diseases.

## Coding Patterns and Conventions

- **C# Files and Structure:**
  - The mod consists of three main C# scripts located under the `Source\HealingGun` directory.
  - Common C# naming conventions are adhered to, with PascalCase for types and methods.
  - Attributes like `[HarmonyPatch]` are used to denote patched methods.

- **XML File Usage:**
  - There are eight XML files defining essential elements like DamageDefs and ResearchProjectDefs.
  - Use consistent naming and proper indentation to maintain readability and structure.

## XML Integration

XML files are crucial for defining game elements within RimWorld. The Healing Gun mod utilizes XML files to configure various in-game definitions.

- **Defs Files:**
  - **DamageDef:** Specifies the properties of the healing effect delivered by the gun.
  - **ResearchProjectDef:** Used for defining the research project required to unlock the Healing Gun.
  - **SoundDef:** Represents the sound played when the Healing Gun is fired.
  - **ThingDef:** Contains the definitions related to the physical attributes of the Healing Gun.

When integrating XML, ensure changes are seamlessly tied with corresponding C# logic.

## Harmony Patching

Harmony is utilized to modify existing vanilla game behavior via patches. This enables the introduction of custom behaviors with minimal disruption.

- **Patch Structure:**
  - Use `[HarmonyPatch]` to target specific methods for modification.
  - Example usage includes modifying target-finding logic to prioritize wounded allies when the Healing Gun is equipped.
  - Ensure patches are efficient and do not cause unintended side effects.

## Suggestions for Copilot

- **Code Completions:**
  - Assist in generating method stubs for patch methods.
  - Predict and suggest relevant Harmony annotations for patching game methods.

- **XML Completeness:**
  - Facilitate XML attribute suggestions based on existing tags.
  - Auto-complete frequently used XML structure to enhance XML development speed.

- **Efficiency Tips:**
  - Suggest code optimizations, especially in loops and recursive functions, to maintain game performance.
  - Identify and propose improvements in exception handling, focusing on smooth gameplay experience during errors.

- **Integration Assistance:**
  - Aid in linking XML elements with C# methods, ensuring harmonious functionality between game definitions and code.
  
By adhering to these guidelines, development on the Healing Gun mod can proceed smoothly, leveraging both manual implementation and GitHub Copilot's capabilities effectively.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

