import { Component, Input } from '@angular/core';

@Component({
  selector: 'shared-table',
  standalone: true,
  template: `
    <div class="bg-white border border-gray-200 rounded-lg p-4">
      @if (title) {
        <h2 class="text-lg font-medium text-gray-700 mb-4">{{ title }}</h2>
      }
      <div class="overflow-x-auto">
        <table class="w-full border-collapse">
          <thead>
            <tr>
              @for (col of columns; track col) {
                <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">{{ col }}</th>
              }
            </tr>
          </thead>
          <tbody>
            @for (row of rows; track $index) {
              <tr>
                @for (cell of row; track $index) {
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ cell }}</td>
                }
              </tr>
            }
          </tbody>
        </table>
      </div>
    </div>
  `
})
export class TableComponent {
  @Input() title = '';
  @Input() columns: string[] = [];
  @Input() rows: string[][] = [];
}
