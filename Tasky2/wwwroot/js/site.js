// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $('#createTaskBtn').on('click',
        function () {

            $.ajax({
                type: 'POST',
                url: 'Create',
                data: $('#createTaskForm').serialize(),
                success: function (d) {
                    //success do something
                    window.location.href = 'MyTask';
                }
            });
        });

    $('#taskCompleteBtn').on('click',
        function () {
            var taskId = $('#taskIdHidden').val();

            $.post('CompleteTask',
                {
                    'taskId': taskId
                },
                function (response) {
                    $('#completedModal').modal('toggle');
                    location.reload();
                }
            );

        });


    $('#taskDeleteBtn').on('click',
        function () {
            var taskId = $('#taskIdHidden').val();

            $.post('DeleteTask',
                {
                    'taskId': taskId
                },
                function (response) {
                    $('#deleteModal').modal('toggle');
                    location.reload();
                }
            );

        });


    $('button').on('click',
        function () {
            var taskId = $(this).closest('tr').find('td:first').text();


            $('#taskIdHidden').val(taskId);
            
        });


    $('input[type="checkbox"]').on('click',
        function () {
            var taskId = $(this).closest('tr').find('td:first').text();

            $('#taskIdHidden').val(taskId);


        });

});