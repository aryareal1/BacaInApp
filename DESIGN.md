# BacaIn Design Guide

## Direction

**Forest & Paper:** crisp forest green, clean light background, and deep charcoal.

BacaIn is a school-library application for students and librarians. Its interface should feel calm, approachable, and academic without looking dated. Prioritize readable catalogs, clear borrowing states, and efficient library administration over decoration.

Source: [project wireframe](docs/plan.drawio.jpg) and [editable plan](docs/plan.drawio).

The diagram's dark background is not an application theme requirement. Use a light-first interface. Students and librarians share one visual system; distinguish roles through navigation and available actions, not separate branding.

## Color Palette

| Role | Color | Token | Usage |
| --- | --- | --- | --- |
| Page background | `#F2F2F2` | `--background-50` | Main application canvas and login background |
| Surface | `#FFFFFF` | N/A | Cards, tables, sidebar, dialogs, and inputs |
| Primary | `#397029` | `--primary-700` | Primary actions, links, and active navigation text |
| Primary hover | `#264A1C` | `--primary-800` | Hover state for primary actions |
| Selected background | `#DFF1DA` | `--primary-100` | Selected navigation items and subtle selection surfaces |
| Main text | `#1A1A1A` | `--text-900` | Headings, labels, and body text |
| Secondary text | `#666666` | `--text-600` | Supporting descriptions and metadata |
| Subtle divider | `#CCCCCC` | `--background-200` | Table separators and decorative boundaries |
| Control border | `#808080` | `--background-500` / `--text-500` | Input and outlined-button boundaries |
| Decorative accent | `#76C33C` | `--accent-500` | Small decorative details only |

### Color Tokens

```css
--text-50: #f2f2f2;
--text-100: #e6e6e6;
--text-200: #cccccc;
--text-300: #b3b3b3;
--text-400: #999999;
--text-500: #808080;
--text-600: #666666;
--text-700: #4d4d4d;
--text-800: #333333;
--text-900: #1a1a1a;
--text-950: #0d0d0d;

--background-50: #f2f2f2;
--background-100: #e6e6e6;
--background-200: #cccccc;
--background-300: #b3b3b3;
--background-400: #999999;
--background-500: #808080;
--background-600: #666666;
--background-700: #4d4d4d;
--background-800: #333333;
--background-900: #1a1a1a;
--background-950: #0d0d0d;

--primary-50: #eff8ec;
--primary-100: #dff1da;
--primary-200: #bfe3b5;
--primary-300: #9fd68f;
--primary-400: #7ec86a;
--primary-500: #5eba45;
--primary-600: #4b9537;
--primary-700: #397029;
--primary-800: #264a1c;
--primary-900: #13250e;
--primary-950: #091307;

--secondary-50: #f4faeb;
--secondary-100: #e9f5d6;
--secondary-200: #d2ebad;
--secondary-300: #bce085;
--secondary-400: #a5d65c;
--secondary-500: #8fcc33;
--secondary-600: #72a329;
--secondary-700: #567a1f;
--secondary-800: #395214;
--secondary-900: #1d290a;
--secondary-950: #0e1405;

--accent-50: #f1f9eb;
--accent-100: #e4f3d8;
--accent-200: #c8e7b1;
--accent-300: #addb8a;
--accent-400: #92cf63;
--accent-500: #76c33c;
--accent-600: #5f9c30;
--accent-700: #477524;
--accent-800: #2f4e18;
--accent-900: #18270c;
--accent-950: #0c1406;
```

Neutral backgrounds and white surfaces should occupy most of each screen. Green identifies interaction and selection. Decorative accent is optional: do not use it for body text, status indicators, or primary button fills.

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
- Keep decoration restrained; optional accent details must not compete with the form.
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
| White `#FFFFFF` | Primary `#397029` | 5.96:1 |
| Main text `#1A1A1A` | Page `#F2F2F2` | 15.55:1 |
| Secondary text `#666666` | Surface `#FFFFFF` | 5.74:1 |
| Primary `#397029` | Selected `#DFF1DA` | 5.03:1 |


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
