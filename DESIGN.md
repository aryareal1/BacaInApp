# BacaIn Design Guide

## Direction

**Forest & Paper:** muted green, warm off-white, and dark charcoal.

BacaIn is a school-library application for students and librarians. Its interface should feel calm, approachable, and academic without looking dated. Prioritize readable catalogs, clear borrowing states, and efficient library administration over decoration.

Source: [project wireframe](docs/plan.drawio.jpg) and [editable plan](docs/plan.drawio).

The diagram's dark background is not an application theme requirement. Use a light-first interface. Students and librarians share one visual system; distinguish roles through navigation and available actions, not separate branding.

## Color Palette

| Role | Color | Usage |
| --- | --- | --- |
| Page background | `#F7F8F4` | Main application canvas and login background |
| Surface | `#FFFFFF` | Cards, tables, sidebar, dialogs, and inputs |
| Primary | `#2F5D50` | Primary actions, links, and active navigation text |
| Primary hover | `#24483E` | Hover state for primary actions |
| Selected background | `#E5EFE8` | Selected navigation items and subtle selection surfaces |
| Main text | `#24332E` | Headings, labels, and body text |
| Secondary text | `#5F6F67` | Supporting descriptions and metadata |
| Subtle divider | `#D8DFD8` | Table separators and decorative boundaries |
| Control border | `#78877E` | Input and outlined-button boundaries |
| Decorative accent | `#C49A45` | Small decorative details only |

Neutral backgrounds and white surfaces should occupy most of each screen. Green identifies interaction and selection. Gold is optional: do not use it for body text, status indicators, or primary button fills.

## Status Colors

Status colors communicate meaning independently of the brand palette. Always display a text label; never rely on color alone.

| Meaning | Text and icon | Badge background | Examples |
| --- | --- | --- | --- |
| Success | `#166534` | `#DCFCE7` | Available, returned, successful check-in |
| Information | `#1E40AF` | `#DBEAFE` | Borrowed, active loan |
| Attention | `#92400E` | `#FEF3C7` | Pending reservation, due soon |
| Error or urgent issue | `#991B1B` | `#FEE2E2` | Overdue, lost, failed operation |
| Inactive | `#475569` | `#F1F5F9` | Cancelled, expired |

Display **Damaged** as a condition label. It is not automatically an application error. Keep copy condition, copy availability, loan status, and reservation status distinct.

## Layout and Components

### Navigation

- Use a white sidebar with stable navigation placement.
- Mark the current page with pale-green background, green text, and a visible indicator such as a leading bar.
- Keep role-specific destinations consistent with the wireframe.
- Keep logout visually separate from frequent navigation actions.

### Tables and Catalog

- Use white rows, subtle dividers, and lightly tinted headers.
- Keep titles and important values in main text; use secondary text for supporting metadata.
- Label action columns clearly. Keep row actions neutral unless they are the screen's main action.
- Use labeled status badges instead of tinting entire rows.
- Let book covers provide visual variety; avoid additional decorative colors across catalog rows.
- Preserve readable column widths. Do not truncate important identifiers or dates without a way to inspect the full value.

### Buttons

- **Primary:** green fill, white text. Use for actions such as **Log In**, **Reserve Book**, and **Save**.
- **Secondary:** white or neutral fill with a visible border. Use for **View Detail**, **Back**, and **Print**.
- **Destructive:** explicit action label and error color. Confirm irreversible operations.
- Keep one visually dominant action per form or task area.
- Provide distinct hover, pressed, keyboard-focus, and disabled states. Do not use color as the only distinction between enabled and disabled controls.

### Forms and Dialogs

- Use persistent labels above or beside inputs; placeholders are supplementary, not replacements for labels.
- Use white input surfaces and the control-border color, not the subtle-divider color, for editable boundaries.
- Show validation messages next to the relevant field with clear corrective text.
- Keep keyboard focus visible with a primary-colored outline or equivalent native focus indicator.
- Preserve entered values when validation fails.

### Administration

- `AdminForm` uses a white sidebar and a `Guna2Panel` content host. Books, Loans & Returns, Students, and Reports are separate designer-editable `UserControl` pages under `BacaIn/Controls`.
- Sidebar navigation switches existing page instances, preserves entered UI values, and identifies the selected destination with a pale-green surface and a leading green indicator. Books is the initial page; logout remains separate and unwired.
- Books and Students provide labeled search inputs, primary add actions, and empty management tables. Loans & Returns provides a student-selection area, loan search, Create Loan, and an empty loans table with Return actions.
- Reports provides report-type and date selectors, Apply and Print / Save PDF actions, summary cards, and an empty Loans & Returns preview. Em dashes mean values are not connected, not zero totals.
- Admin pages are design-only: search, CRUD, student selection, lending/returns, report generation, printing, and logout have no business handlers. Preview hints make this explicit; no fictional records are loaded.
- Application startup remains `LoginForm`; authentication and routing from login to administration are intentionally unchanged.

### Student Portal

- `StudentForm` matches the `AdminForm` structure with a white sidebar, role label `STUDENT PORTAL`, and a `Guna2Panel` content host.
- Student navigation includes 4 primary sidebar destinations: **Catalog**, **My Loans**, **My Reservations**, and **Check-in History**. Catalog is the initial selected page; logout remains separate and unwired.
- **Book Detail** (`BookDetailPage`) is accessed through the catalog's **View Detail** action and returns via **← Back to Catalog**, keeping Catalog active in the sidebar.
- Student pages are designer-editable `UserControl`s under `BacaIn/Controls`: `CatalogPage`, `BookDetailPage`, `MyLoansPage`, `MyReservationsPage`, and `CheckInHistoryPage`.
- **Catalog** provides keyword search, availability filter, book list table (Title, Author, Available, View Detail action), and pagination.
- **Book Detail** shows book cover placeholder, metadata (title, author, publisher, year, ISBN, description), available copies count, Reserve Book primary action, and library copies table (Barcode, Condition, Status).
- **My Loans** provides status filtering (All, Active, Overdue, Returned), summary counts, loans table (Book / Copy, Borrowed, Due, Returned, Status), and return policy guidance.
- **My Reservations** provides status filtering, pending/ready summary counts, reservations table (Book title, Reserved, Status, Queue, Cancel action), and pickup guidance.
- **Check-in History** provides date-range filtering (From, To, Apply, Reset), attendance count summary, visits table (Date, Check-in Time), and local-time guidance.
- Pages follow design preview conventions: schema-aligned controls, empty tables, and explicit preview labels.

### Login

- Use an off-white page and a white form panel.
- Use green for the heading or logo and the primary login action.
- Keep decoration restrained; optional gold details must not compete with the form.
- `BacaIn/LoginForm.Designer.cs` implements a centered white `Guna2Panel`, an image-backed `Guna2PictureBox` logo, native autosizing labels, masked `Guna2TextBox` inputs, and a full-width primary `Guna2Button`. Native table layouts handle centering and resizing, with scrolling available when space is constrained.
- Typography uses a 28pt bold brand heading, 11pt bold welcome and field labels, 11pt inputs and bold login action, and 10.5pt supporting copy. Welcome text, librarian-access guidance, and a school-library footer add context without introducing extra actions.
- Original logo asset: `BacaIn/Assets/bacain-logo.png`, a transparent 512×512 open-book and leaf mark. `LoginForm.resx` embeds it; `Guna2PictureBox` displays it with `SizeMode.Zoom`, preserving its aspect ratio.
- Login remains design-only: keyboard order is Username, Password, then Log In; Enter targets Log In. Authentication, validation messages, and navigation are not wired yet.

## Typography and Spacing

- Prefer the platform's native UI font; on Windows, use Segoe UI or the system default.
- Use a small, consistent hierarchy: page heading, section heading, body, and supporting text.
- Use weight and spacing before adding color to establish hierarchy.
- Follow a 4-unit spacing scale, with 8, 16, and 24 as common gaps. Respect platform DPI scaling rather than assuming fixed physical pixels.
- Keep tables compact enough for library workflows without crowding controls or reducing readability.

## Accessibility

Target WCAG AA contrast: at least **4.5:1** for normal text, **3:1** for large text, and **3:1** for essential control boundaries and visual indicators against adjacent colors.

Calculated contrast for core palette pairs:

| Foreground | Background | Contrast |
| --- | --- | --- |
| White `#FFFFFF` | Primary `#2F5D50` | 7.49:1 |
| Main text `#24332E` | Page `#F7F8F4` | 12.40:1 |
| Secondary text `#5F6F67` | Surface `#FFFFFF` | 5.31:1 |
| Primary `#2F5D50` | Selected `#E5EFE8` | 6.37:1 |

These ratios validate specific color pairs, not the whole interface. Check actual rendered controls, focus indicators, scaling, and state combinations during implementation.

- Pair status colors with labels and, where useful, icons.
- Support keyboard navigation and logical focus order.
- Do not remove native focus cues without an equally visible replacement.
- Verify readability at increased OS text size and display scaling.
- Keep errors actionable and distinguish empty results from failed requests.

## Screen Review Checklist

- [ ] Neutral surfaces dominate; green marks actions and selection.
- [ ] Student and librarian screens use the same palette and component conventions.
- [ ] Current navigation destination is identifiable without color alone.
- [ ] Primary action is clear; secondary actions do not compete with it.
- [ ] Status labels distinguish availability, condition, loans, and reservations.
- [ ] Text, editable boundaries, and focus indicators have sufficient contrast.
- [ ] Keyboard navigation, display scaling, validation, and empty/error states remain usable.
